import { Injectable } from "@angular/core";
import { DoOverRepository } from "../data/repositories/dooverRepository";
import { firstValueFrom } from "rxjs";
import { LotoFacilSmall } from "../models/lotoFacilSmall";

@Injectable({
  providedIn: 'root'
})
export class DoOverService {

  private dataCache: LotoFacilSmall | null = null;
  
  constructor(private repository: DoOverRepository) {}

   async preloadData(): Promise<void> {
     if (!this.dataCache) {
       try {
         const data = await this.repository.getData();
         this.dataCache = data;
       } catch (error) {
         console.error('Error preloading data:', error);
       }
     }
   }
 
   async getData(): Promise<LotoFacilSmall> {
     try {
       const data = await this.repository.getData();
       this.dataCache = data;   
     
       const resultados: number[] = data.values || [];  
   
       let smallModel: LotoFacilSmall = {
         concurso: data.concurso,
         values: resultados
       };  
       
       return smallModel;
     } catch (error) {
       console.error('Error fetching data:', error);
       throw error;
     }
   }
}
