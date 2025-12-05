import { Component, OnInit } from '@angular/core';
import { PostService } from 'src/app/services';
import { FilterModel } from 'src/app/shared/models';

interface Post {
  id: number;
  title: string;
  excerpt: string;
  author: string;
  date: string;
  readTime: string;
  image: string;
  category: string;
  tags?: string[];
}

@Component({
  selector: 'app-posts',
  standalone: false,
  templateUrl: './posts.component.html',
  styleUrl: './posts.component.scss'
})
export class PostsComponent implements OnInit {
  searchQuery: string = '';
  selectedFilter: string = 'All';
  trendingTags: string[] = ['#AI', '#Web Dev', '#Design', '#React', '#Career'];

  filters: string[] = ['All', 'Design', 'Web Development', 'UI/UX', 'React'];

  // posts: Post[] = [];

  allPosts: Post[] = [
    {
      id: 1,
      title: 'The Art of Minimalist Design in Modern Web Development',
      excerpt: 'Explore how less can be more when creating impactful digital experiences. Discover...',
      author: 'Sarah Chen',
      date: 'Dec 2, 2024',
      readTime: '5 min read',
      image: 'https://images.unsplash.com/photo-1561070791-2526d30994b5?w=600&h=400&fit=crop',
      category: 'Design'
    },
    {
      id: 2,
      title: 'Building Performant React Applications',
      excerpt: 'Deep dive into optimization techniques that will make your React apps blazingly fast and...',
      author: 'Marcus Johnson',
      date: 'Dec 1, 2024',
      readTime: '8 min read',
      image: 'https://images.unsplash.com/photo-1517694712202-14dd9538aa97?w=600&h=400&fit=crop',
      category: 'Web Development'
    },
    {
      id: 3,
      title: 'The Future of AI in Creative Industries',
      excerpt: 'How artificial intelligence is reshaping the creative landscape and what it means for artists...',
      author: 'Elena Rodriguez',
      date: 'Nov 30, 2024',
      readTime: '6 min read',
      image: 'https://images.unsplash.com/photo-1677442d019cecf8b13b3b63f6b30194?w=600&h=400&fit=crop',
      category: 'AI'
    },
    {
      id: 4,
      title: 'Mastering CSS Grid: A Complete Guide',
      excerpt: 'Everything you need to know about CSS Grid to create complex, responsive layouts with ease.',
      author: 'David Kim',
      date: 'Nov 28, 2024',
      readTime: '7 min read',
      image: 'https://images.unsplash.com/photo-1633356122544-f134324ef6db?w=600&h=400&fit=crop',
      category: 'Web Development'
    },
    {
      id: 5,
      title: 'Understanding TypeScript Generics',
      excerpt: 'A practical guide to writing type-safe, reusable code with TypeScript generics.',
      author: 'Alex Thompson',
      date: 'Nov 26, 2024',
      readTime: '9 min read',
      image: 'https://images.unsplash.com/photo-1633356122544-f134324ef6db?w=600&h=400&fit=crop',
      category: 'Web Development'
    },
    {
      id: 6,
      title: 'The Psychology of Color in UI Design',
      excerpt: 'How color choices influence user behavior and emotional responses in digital products.',
      author: 'Jessica Wright',
      date: 'Nov 24, 2024',
      readTime: '5 min read',
      image: 'https://images.unsplash.com/photo-1561070791-2526d30994b5?w=600&h=400&fit=crop',
      category: 'Design'
    }
  ];

  filterModel: FilterModel = new FilterModel();
  posts = Array<any>();
  isModelLoaded = false;
  totalCount = 0;

  constructor(private readonly postService: PostService) { }
  ngOnInit() {
    this.getPosts();
  }

  updateFilterModel(): void {

  }

  resetFIlterModel(): void {

  }

  getPosts(): void {
    this.filterModel.sort = 'title'
    this.postService.getPosts(this.filterModel).subscribe({
      next: (res) => {
        this.isModelLoaded = true;
        this.totalCount = res.totalCount;
        this.posts = res.items;
      },
      error: (err) => {
        this.isModelLoaded = true;
        console.log(err);
      }
    })
  }

  filterPosts() {
    if (this.selectedFilter === 'All') {
      this.posts = this.allPosts;
    } else {
      this.posts = this.allPosts.filter(post => post.category === this.selectedFilter);
    }

    if (this.searchQuery) {
      this.posts = this.posts.filter(post =>
        post.title.toLowerCase().includes(this.searchQuery.toLowerCase()) ||
        post.excerpt.toLowerCase().includes(this.searchQuery.toLowerCase())
      );
    }
  }
}
