import { CorrelationPlaces } from "src/app/models/correlationPlaces";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({ providedIn: 'root' })
export class CorrelationsRepository {

  private endPoint = 'http://localhost:7139/api/LotoFacilCorrelation'; 

  constructor(private http: HttpClient) {}

  getData(): Observable<number [][]> {      
    return this.http.get<any>(this.endPoint);
  } 
  
  getPlacesData(key: number): Observable<CorrelationPlaces> {
    return this.http.get<CorrelationPlaces>(`${this.endPoint}places/${key}`);
  } 
}
