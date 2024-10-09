import { Injectable } from "@angular/core";
import { firstValueFrom } from "rxjs";
import { OcurrencesRepository } from "../data/repositories/ocurrencesRepository";

@Injectable({
  providedIn: 'root'
})
export class OcurrencesService {
  private dataCache: number[] | null = null;

  constructor(private repository: OcurrencesRepository) {}

  async preloadData(): Promise<void> {
    if (!this.dataCache) {
      try {
        const data = await firstValueFrom(this.repository.getData());
        this.dataCache = data; 
      } catch (error) {
        console.error('Error preloading overdue data:', error);
      }
    }
  }

  public async getData(): Promise<number[]> {
    if (this.dataCache) {
      return this.dataCache;
    }

    try {
      const data = await firstValueFrom(this.repository.getData());
      this.dataCache = data; 
      return data;
    } catch (error) {
      console.error('Error fetching occurrences data:', error);
      throw error;
    }
  }
}
