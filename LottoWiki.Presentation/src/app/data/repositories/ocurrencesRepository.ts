import { LotoFacilSmall } from "src/app/models/lotoFacilSmall";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { firstValueFrom } from "rxjs";

@Injectable({ providedIn: 'root' })
export class OcurrencesRepository {
  private endPoint = 'https://localhost:44344/api/LotoFacilOcurrences/Ocurrences';

  constructor(private http: HttpClient) {}

  async getData(): Promise<LotoFacilSmall> {
    try {
      const data = await firstValueFrom(this.http.get<LotoFacilSmall>(this.endPoint));
      return data;
    } catch (error) {
      console.error('Erro ao buscar os dados:', error);
      throw error;
    }
  }
}
