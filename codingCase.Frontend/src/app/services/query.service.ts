import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { QueryResult } from '../model/queryResult';
import { environment } from '../../environments/environment';
import { firstValueFrom } from 'rxjs';
import { ItemDetails } from '../model/itemDetails';

@Injectable({
  providedIn: 'root'
})
export class QueryService {

  private baseUrl = environment.backendUrl;

  constructor(private readonly httpClient: HttpClient) { }

  public query(searchString: string) :Promise<QueryResult[]>{
    return firstValueFrom(this.httpClient.get<QueryResult[]>(`${this.baseUrl}/query/?searchString=${searchString}`));
  }

  public getItemDetails(itemId: string) :Promise<ItemDetails> {
    return firstValueFrom(this.httpClient.get<ItemDetails>(`${this.baseUrl}/query/details/?itemId=${itemId}`));
  }
}
