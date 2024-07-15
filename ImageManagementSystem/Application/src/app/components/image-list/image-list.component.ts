import { Component, OnInit } from '@angular/core';
import { Image } from '../../models/image.model';
import { ImageService } from '../../services/image.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-image-list',
  templateUrl: './image-list.component.html',
  styleUrl: './image-list.component.css'
})
export class ImageListComponent implements OnInit {
  images: Image[] = [];
  showModal: boolean = false;
  selectedImage: Image = {
    id: 0,
    user: '',
    dateCreated: new Date(),
    description: '',
    url: ''
  };

  constructor(private imageService: ImageService, private router: Router) { }

  ngOnInit(): void {
    this.loadImages();
  }

  loadImages(): void {
    this.imageService.getImages().subscribe(images => this.images = images);
  }

  deleteImage(id: number): void {
    this.imageService.deleteImage(id).subscribe(() => this.loadImages());
  }

  openAddModal(): void {
    this.selectedImage = {
      id: 0,
      user: '',
      dateCreated: new Date(),
      description: '',
      url: ''
    };
    this.showModal = true;
  }

  openEditModal(image: Image): void {
    this.selectedImage = image;
    this.showModal = true;
  }

  closeModal(): void {
    this.showModal = false;
    this.selectedImage = {
      id: 0,
      user: '',
      dateCreated: new Date(),
      description: '',
      url: ''
    };
    this.loadImages();
  }

}
