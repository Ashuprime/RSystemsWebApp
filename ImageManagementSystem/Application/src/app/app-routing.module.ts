import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ImageListComponent } from './components/image-list/image-list.component';
import { ImageFormComponent } from './components/image-form/image-form.component';

const routes: Routes = [
  { path: '', redirectTo: '/images', pathMatch: 'full' },
  { path: 'images', component: ImageListComponent },
  { path: 'images/add', component: ImageFormComponent },
  { path: 'images/edit/:id', component: ImageFormComponent } 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
