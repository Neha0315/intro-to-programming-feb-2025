import {
  patchState,
  signalStore,
  withComputed,
  withHooks,
  withMethods,
  withState,
} from '@ngrx/signals';
import { addEntities, addEntity, withEntities } from '@ngrx/signals/entities';
import { ResourceListItem, ResourceListItemCreateModel } from '../types';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { mergeMap, pipe, switchMap, tap } from 'rxjs';
import { ResourceDataService } from './resource-data.service';
import { computed, inject } from '@angular/core';
import { withDevtools } from '@angular-architects/ngrx-toolkit';

// Higher-Ordered Function
export const ResourceStore = signalStore(
  withDevtools('resources'),
  withState<{ filteredBy: string | null; tags: string[] }>({
    filteredBy: null,
    tags: [],
  }),
  withEntities<ResourceListItem>(),
  withComputed((store) => {
    return {
      filteredResourceList: computed(() => {
        const filteredBy = store.filteredBy();
        if (filteredBy === null) {
          return store.entities();
        }
        return store.entities().filter((r) => r.tags.includes(filteredBy));
      }),
    };
  }),
  withMethods((store) => {
    const service = inject(ResourceDataService);
    return {
      setFilteredBy: (filteredBy: string | null) =>
        patchState(store, { filteredBy }),
      add: rxMethod<ResourceListItemCreateModel>(
        pipe(
          mergeMap(
            (
              item, // mergeMap - don't cancel "inflight" requests, I need the results of each of these calls.
            ) =>
              service.addResource(item).pipe(
                tap((r) => patchState(store, addEntity(r))),
                tap((r) => {
                  const tags = r.tags;
                  const tagList = store.tags();
                  const newTags = new Set([...tagList, ...tags]);
                  patchState(store, { tags: [...newTags] });
                }),
              ),
          ),
        ),
      ),
      load: rxMethod<void>(
        pipe(
          switchMap(() =>
            // switchMap - cancel "inflight" requests, I only care about the latest one.
            service.getResource().pipe(
              tap((r) => patchState(store, addEntities(r))),
              tap((items) => {
                const tagsOfItemsFromApi = items
                  .map((item) => item.tags)
                  .flat(); // [ 'angular', 'ngrx', 'angular', 'rxjs']

                const uniqueTags = Array.from(new Set(tagsOfItemsFromApi)); // this gives me just the unique items

                const tagList = store.tags();
                const newTags = uniqueTags.filter(
                  (tag) => !tagList.includes(tag),
                );
                patchState(store, { tags: [...newTags] });
              }),
            ),
          ),
        ),
      ),
    };
  }),
  withHooks({
    onInit(store) {
      store.load();
    },
  }),
);
