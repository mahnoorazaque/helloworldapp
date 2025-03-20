import { Component, OnInit } from '@angular/core';
import { ApiService } from './api.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true, // Standalone Component
  imports: [CommonModule], // Required for Angular features
  template: `<h1>{{ message }}</h1>`, // Direct inline template
})
export class AppComponent implements OnInit {
  message: string = 'Loading...'; // Define message property

  constructor(private apiService: ApiService) {}

  ngOnInit() {
    this.apiService.getHelloMessage().subscribe(
      (data) => (this.message = data), // Set API response to message
      (error) => (this.message = 'Error fetching data') // Handle errors
    );
  }
}

