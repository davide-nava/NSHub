import CustomStore from 'devextreme/data/custom_store';

export interface CustomStoreConfig<T> {
  key: keyof T | string;
  load: () => Promise<T[]>;
}

export class CustomStoreAdapter {
  static create<T>(config: CustomStoreConfig<T>): CustomStore<T, unknown> {
    return new CustomStore<T, unknown>({
      key: config.key as string,
      load: async () => {
        try {
          const result = await config.load();
          return {
            data: result,
          };
        } catch (err: unknown) {
          const message = err instanceof Error ? err.message : 'Data Loading Error';
          throw new Error(message);
        }
      },
    });
  }
}

