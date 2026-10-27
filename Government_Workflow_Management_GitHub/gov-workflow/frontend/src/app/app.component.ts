import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
interface RequestItem {id:number;title:string;department:string;description:string;status:string;createdUtc:string}
@Component({selector:'app-root',standalone:true,imports:[CommonModule,FormsModule],templateUrl:'./app.component.html'})
export class AppComponent implements OnInit {
  readonly api='http://localhost:5080/api/requests';
  requests:RequestItem[]=[]; title='';department='';description='';error='';busy=false;
  constructor(private http:HttpClient){}
  ngOnInit(){this.refresh()}
  refresh(){this.http.get<RequestItem[]>(this.api).subscribe({next:data=>{this.requests=data;this.error=''},error:()=>this.error='Cannot connect to API. Start the backend on port 5080.'})}
  create(){if(!this.title.trim()||!this.department.trim())return;this.busy=true;this.http.post(this.api,{title:this.title,department:this.department,description:this.description}).subscribe({next:()=>{this.title='';this.department='';this.description='';this.busy=false;this.refresh()},error:()=>{this.error='Unable to create request';this.busy=false}})}
  setStatus(item:RequestItem,status:string){this.http.patch(`${this.api}/${item.id}/status`,{status}).subscribe({next:()=>this.refresh(),error:()=>this.error='Unable to update status'})}
  count(status:string){return this.requests.filter(x=>x.status===status).length}
}
