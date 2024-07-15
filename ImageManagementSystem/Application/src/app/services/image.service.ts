import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Image } from '../models/image.model';

@Injectable({
  providedIn: 'root'
})
export class ImageService {
  private apiUrl = 'https://localhost:7078/api/image';
  readonly httpHeaders: HttpHeaders = new HttpHeaders({'Content-Type': 'application/json'});
  readonly httpOptions = {
    headers: this.httpHeaders,
    withCredentials: false
  };

  constructor(private http: HttpClient) { }
  

  getImages(): Observable<Image[]> {
    return this.http.get<Image[]>(this.apiUrl, this.httpOptions);
  }

  getImage(id: number): Observable<Image> {
    return this.http.get<Image>(`${this.apiUrl}/${id}`, this.httpOptions);
  }

  addImage(image: Image): Observable<Image> {
    return this.http.post<Image>(this.apiUrl, image, this.httpOptions);
  }

  updateImage(image: Image): Observable<Image> {
    return this.http.put<Image>(`${this.apiUrl}/${image.id}`, image, this.httpOptions);
  }

  deleteImage(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`, this.httpOptions);
  }
}