import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-common-modal',
  templateUrl: './common-modal.component.html',
  styleUrl: './common-modal.component.css'
})
export class CommonModalComponent {
  @Input() modalTitle: string = '';
  @Input() showModal: boolean = false;
  @Output() close = new EventEmitter<void>();

  onClose(): void {
    this.close.emit();
  }

}
