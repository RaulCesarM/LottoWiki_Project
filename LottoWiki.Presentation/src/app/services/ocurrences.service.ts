import { Injectable } from "@angular/core";
import { firstValueFrom } from "rxjs";
import { OcurrencesRepository } from "../data/repositories/ocurrencesRepository";

@Injectable({
  providedIn: 'root'
})
export class OcurrencesService {
  private dataCache: number[] = [];

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

  async getData(): Promise<number[]> {
    try {
      let data = await firstValueFrom(await this.repository.getData());
      this.dataCache = data;
      if (!data) {
         data = this.dataCache;
      }
      return data;
    } catch (error) {
      console.error('Error fetching overdue data:', error);
      throw error;
    }
  }
}

