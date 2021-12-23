import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Response } from '../models/response';

@Injectable({
  providedIn: 'root'
})

export class ApiClienteService {

  url: string = 'https://localhost:44303/api/Activity/ListaActividad';

  constructor(
    private _http: HttpClient
  ) { }

  getListaActividad() : Observable<Response> {
    return this._http.get<Response>(this.url);
  }
}
