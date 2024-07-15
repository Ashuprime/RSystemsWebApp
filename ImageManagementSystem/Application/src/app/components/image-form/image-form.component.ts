import { Component, Input, OnInit, Output, EventEmitter, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ImageService } from '../../services/image.service';
import { Image } from '../../models/image.model';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-image-form',
  templateUrl: './image-form.component.html',
  styleUrl: './image-form.component.css'
})
export class ImageFormComponent implements OnInit {
  @Input() image: Image = {
    id: 0,
    user: '',
    dateCreated: new Date(),
    description: '',
    url: ''
  };
  @Output() formClose = new EventEmitter<void>();

  imageForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private imageService: ImageService
  ) {
    this.imageForm = this.fb.group({
      user: ['', Validators.required],
      dateCreated: ['', Validators.required],
      description: ['', Validators.required],
      url: ['', [Validators.required, Validators.pattern('https?://.+')]]
    });
  }

  ngOnInit(): void {
    if (this.image && this.image.id) {
      this.imageForm.patchValue(this.image);
    }
  }

  ngOnChanges(changes: SimpleChanges): void {
    console.log(this.image);    
    if (this.image) {
      this.imageForm.patchValue(this.image);
    }
    
  }
  
  saveImage(): void {
    if (this.imageForm.valid) {
      if (this.image && this.image.id) {
        this.imageService.updateImage({ ...this.image, ...this.imageForm.value }).subscribe(() => {
          this.formClose.emit();
        });
      } else {
        this.imageService.addImage(this.imageForm.value).subscribe(() => {
          this.formClose.emit();
        });
      }
    }
  }

  closeForm(): void {
    this.formClose.emit();
  }

}
