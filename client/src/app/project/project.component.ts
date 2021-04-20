import { Component, OnInit } from '@angular/core';
import { Apollo } from 'apollo-angular';
import { CREATE_PROJECT, DELETE_PROJECT, UPDATE_PROJECT } from './mutations';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { PROJECT_QUERY } from './queries';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css']
})
export class ProjectComponent implements OnInit {

 
  constructor(private apollo: Apollo) { 
    }

  ngOnInit(): void {
   
  }

  
}

  

 
