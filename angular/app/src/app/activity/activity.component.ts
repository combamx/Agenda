import { Component, OnInit } from '@angular/core';
import { ApiClienteService } from '../services/api-cliente.service';
import { Response } from '../models/response';
import { ResponseActivity } from '../models/responseActivity';

@Component({
  selector: 'app-activity',
  templateUrl: './activity.component.html',
  styleUrls: ['./activity.component.sass']
})
export class ActivityComponent implements OnInit {

  public lst: ResponseActivity[] = [];

  constructor(
    private apiCliente: ApiClienteService
  ) {

  }

  ngOnInit(): void {
    this.getListaActividad();
  }

  getListaActividad(): void {
    this.apiCliente.getListaActividad().subscribe( response => {
      this.lst = response.data;
    });
  }

}
