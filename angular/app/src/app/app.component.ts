import { Component, OnInit } from '@angular/core';

declare var $: any;
declare function CargarDatosGrid() : any;
declare function CargarPropiedades() : any;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})

export class AppComponent implements OnInit {
  ngOnInit()
  {
    $(document).ready(function () {
      $('#agregarFecha').datepicker({
          format: 'yyyy-mm-dd',
      });

      $('#editarFecha').datepicker({
          format: 'yyyy-mm-dd',
      });

      CargarDatosGrid();
      CargarPropiedades();

      $('#sistemMsg').on('hidden.bs.modal', function () {
          if ($('#activityAgregar').is(':visible')) {
              $('#activityAgregar').modal('hide');
          }

          if ($('#activityEditar').is(':visible')) {
              $('#activityEditar').modal('hide');
          }
      });
    });
  }
}
