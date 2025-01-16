import { Injectable } from "@angular/core";
import { OverdueRepository } from "../data/repositories/overdueRepository";
import { firstValueFrom } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class OverdueService {
  private dataCache: number[] | null = null;

  constructor(private repository: OverdueRepository) {}

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
      let data = await firstValueFrom(this.repository.getData());
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
