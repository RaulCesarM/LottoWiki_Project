import { Injectable } from '@angular/core';
import { CorrelationsRepository } from '../data/repositories/correlationsRepository';
import { firstValueFrom } from 'rxjs';
import { CorrelationPlaces } from '../models/correlationPlaces';

@Injectable({
  providedIn: 'root'
})
export class CorrelationsService {

  private dataCache: number[][] | null = null;
  private placesDataCache: Map<number, CorrelationPlaces> = new Map();

  constructor(private repository: CorrelationsRepository) {}

  async preloadData(): Promise<void> {
    if (!this.dataCache) {
      try {
        const data: number[][] = await firstValueFrom(this.repository.getData());
        this.dataCache = data;
      } catch (error) {
        console.error('Error preloading overdue data:', error);
      }
    }
  }

  async getData(): Promise<number[][]> {
    if (this.dataCache) {
      return this.dataCache;
    }

    try {
      const data = await firstValueFrom(this.repository.getData());
      this.dataCache = data; 
      return data;
    } catch (error) {
      console.error('Error fetching correlation data:', error);
      throw error;
    }
  }

  async getPlacesData(target: number): Promise<CorrelationPlaces> {
    if (this.placesDataCache.has(target)) {
      return this.placesDataCache.get(target)!;
    }

    try {
      const data = await firstValueFrom(this.repository.getPlacesData(target));
      this.placesDataCache.set(target, data); 
      return data;
    } catch (error) {
      console.error(`Error fetching places data for target ${target}:`, error);
      throw error;
    }
  }
}
