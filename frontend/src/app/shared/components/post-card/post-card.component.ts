import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-post-card',
  standalone: false,
  templateUrl: './post-card.component.html',
})
export class PostCardComponent {
  @Input() post: any;
}

interface ProfilePost {
  id: number;
  title: string;
  image: string;
  date: string;
  content:string;
  AuthorName:string;
  timeTORead:string
}
