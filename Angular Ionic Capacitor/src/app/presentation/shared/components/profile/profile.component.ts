import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss'],
})
export class ProfileComponent implements OnInit {
  currentSection: string = 'publicProfile'; // Default section
  isEditMode: boolean = false; // Controls edit mode

  profile = {
    fullName: 'John Doe',
    email: 'johndoe@example.com',
    profilePicture: '',
    bio: 'A passionate learner and enthusiast.',
    url: 'https://example.com',
    favoriteDua: 'Rabbi zidni ilma',
    location: 'New York, USA',
  };

  account = {
    username: 'john_doe',
    password: '********',
  };

  constructor() {}

  ngOnInit(): void {}

  navigateToSection(section: string): void {
    this.currentSection = section;
  }

  toggleEditMode(): void {
    this.isEditMode = !this.isEditMode;
  }

  updateProfile(): void {
    console.log('Profile updated:', this.profile);
    this.isEditMode = false; // Exit edit mode
  }

  updateAccount(): void {
    console.log('Account updated:', this.account);
    this.isEditMode = false; // Exit edit mode
  }

  uploadProfilePicture(event: any): void {
    const file = event.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = () => {
        this.profile.profilePicture = reader.result as string;
      };
      reader.readAsDataURL(file);
    }
  }
}
