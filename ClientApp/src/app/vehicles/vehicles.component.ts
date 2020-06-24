import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-vehicles',
  templateUrl: './vehicles.component.html',
  styleUrls: ['./vehicles.component.css']
})
export class VehiclesComponent {

  public vehicles: Vehicle[];
  public vehicle: Vehicle;
  public showForm = false;

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) {
    this.refresh();
  }

  refresh(){
    this.http.get<Vehicle[]>(this.baseUrl + 'api/vehicles', this.headers()).subscribe(result => {
      this.vehicles = result;
      this.vehicle = {
        color: "#000000",
        manufacturer: "",
        year: 2020,
        mileage: 0
      };
      this.showForm = false;
    }, error => console.error(error));
  }

  save() {
    this.http.post(this.baseUrl + 'api/vehicles', this.vehicle, this.headers()).subscribe(() => {
      this.refresh();
    }, error => console.error(error));
  }

  private headers() {
    return {
      headers: { "Authorization": "Bearer " + sessionStorage.getItem("token") }
    }
  }
}

interface Vehicle {
  color: string;
  year: number;
  manufacturer: string;
  mileage: number;
}
