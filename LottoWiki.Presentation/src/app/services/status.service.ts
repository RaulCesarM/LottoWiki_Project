import { Injectable } from "@angular/core";
import { StatusRepository } from "../data/repositories/statusRepository";
import { firstValueFrom } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class StatusService {
  private cache: string[][] | null = null;
  private concursosCache: number[] = [];

  constructor(private repository: StatusRepository) {}

  async preloadData(): Promise<void> {
    if (!this.cache) {
      const matrix: string[][] = [];
      try {
        const last = await firstValueFrom(this.repository.getLast());
        let contador = 0;
        while (contador <= 24) {
          const id = last - contador;
          const data = await firstValueFrom(this.repository.getById(id));
          contador++;

          if (Array.isArray(data)) {
            matrix.push(data);
            this.concursosCache.push(id); // Armazena o número do concurso
          } else {
            console.warn(`Data for ID ${id} is not an array or is invalid:`, data);
          }
        }
        matrix.reverse();
        this.concursosCache.reverse(); // Garante que os concursos estejam na ordem correta
        this.cache = matrix; 
      } catch (error) {
        console.error('Error preloading status data:', error);
      }
    }
  }

  async getData(): Promise<string[][]> {
    if (this.cache) {
      return this.cache;
    }

    return this.preloadData().then(() => this.cache || []);
  }

  async getConcursos(): Promise<number[]> {
    if (this.concursosCache.length) {
      return this.concursosCache;
    }

    await this.preloadData();
    return this.concursosCache;
  }
}
