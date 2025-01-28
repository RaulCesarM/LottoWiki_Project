import { LotoFacilSmall } from "src/app/models/lotoFacilSmall";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { firstValueFrom, Observable } from "rxjs";
import { mapObject } from "src/app/serialization/mapObject";

@Injectable({ providedIn: 'root' })
export class OverdueRepository {

  constructor(private http: HttpClient) {}

  private endPoint = 'https://localhost:44344/api/LotoFacilOverDue/OverDue';

  async getData(): Promise<LotoFacilSmall> {
    try {
      const data = await firstValueFrom(this.http.get<LotoFacilSmall>(this.endPoint));
      return data;
    } catch (error) {
      console.error('Erro ao buscar os dados:', error);
      throw error;
    }
  }

  public findById(id: number): Observable<LotoFacilSmall> {
    const url = `endPoint/${id}`;
    return this.http.get(url).pipe(mapObject(LotoFacilSmall));
  }

}