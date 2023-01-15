import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Value } from '../models/value';

@Component({
  selector: 'app-value',
  templateUrl: './valueslist.component.html',
  styleUrls: ['./valueslist.component.css']
})
export class ValueComponent {
  constructor(private httpClient:HttpClient){}
  values:Value[]=[];

  ngOnInit(){
    this.getValues().subscribe(data =>{
      this.values = data
    })
  }

  getValues(){
    return this.httpClient.get<Value[]>("https://localhost:7152/api/Bars")
  }
}
