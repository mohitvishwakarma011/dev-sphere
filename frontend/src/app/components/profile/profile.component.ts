import { Component } from '@angular/core';

interface ProfilePost {
  id: number;
  title: string;
  image: string;
  date: string;
}

@Component({
  selector: 'app-profile',
  standalone: false,
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.scss'
})
export class ProfileComponent {
  activeTab: 'posts' | 'saved' | 'liked' = 'posts';

  profile = {
    name: 'Alex Thompson',
    title: 'Full-stack developer',
    bio: 'Passionate about creating beautiful, performant web experiences. Writing about code, design, and the intersection of technology and creativity.',
    joinDate: 'January 2023',
    avatar: 'https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?w=400&h=400&fit=crop',
    backgroundImage: 'https://images.unsplash.com/photo-1561070791-2526d30994b5?w=1200&h=400&fit=crop'
  };

  stats = [
    { label: 'Total Posts', value: 24, icon: 'ri-file-list-line' },
    { label: 'Followers', value: 1250, icon: 'ri-user-follow-line' },
    { label: 'Following', value: 89, icon: 'ri-user-add-line' },
    { label: 'Total Likes', value: 2500, icon: 'ri-heart-line' }
  ];

  posts: ProfilePost[] = [
    {
      id: 1,
      title: 'The Art of Minimalist Design in Modern Web Development',
      image: 'https://images.unsplash.com/photo-1561070791-2526d30994b5?w=400&h=300&fit=crop',
      date: 'Dec 2, 2024'
    },
    {
      id: 2,
      title: 'Building Performant React Applications',
      image: 'https://images.unsplash.com/photo-1517694712202-14dd9538aa97?w=400&h=300&fit=crop',
      date: 'Dec 1, 2024'
    },
    {
      id: 3,
      title: 'The Future of AI in Creative Industries',
      image: 'https://images.unsplash.com/photo-1677442d019cecf8b13b3b63f6b30194?w=400&h=300&fit=crop',
      date: 'Nov 30, 2024'
    },
    {
      id: 4,
      title: 'Mastering CSS Grid: A Complete Guide',
      image: 'https://images.unsplash.com/photo-1633356122544-f134324ef6db?w=400&h=300&fit=crop',
      date: 'Nov 28, 2024'
    }
  ];

  savedPosts: ProfilePost[] = [
    {
      id: 5,
      title: 'Understanding TypeScript Generics',
      image: 'https://images.unsplash.com/photo-1633356122544-f134324ef6db?w=400&h=300&fit=crop',
      date: 'Nov 26, 2024'
    },
    {
      id: 6,
      title: 'The Psychology of Color in UI Design',
      image: 'https://images.unsplash.com/photo-1561070791-2526d30994b5?w=400&h=300&fit=crop',
      date: 'Nov 24, 2024'
    }
  ];

  likedPosts: ProfilePost[] = [
    {
      id: 7,
      title: 'Advanced JavaScript Patterns',
      image: 'https://images.unsplash.com/photo-1517694712202-14dd9538aa97?w=400&h=300&fit=crop',
      date: 'Nov 22, 2024'
    }
  ];

  setActiveTab(tab: 'posts' | 'saved' | 'liked') {
    this.activeTab = tab;
  }

  getActiveTabPosts(): ProfilePost[] {
    switch (this.activeTab) {
      case 'saved':
        return this.savedPosts;
      case 'liked':
        return this.likedPosts;
      default:
        return this.posts;
    }
  }
}
