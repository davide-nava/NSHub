import { computed, inject, Injectable, signal } from '@angular/core';
import { Router } from '@angular/router';
import { AuthResult, User } from '../models/user.model';

const DEFAULT_PATH = '/';
const DEFAULT_USER: User = {
  email: 'sandra@example.com',
  avatarUrl: 'https://js.devexpress.com/Demos/WidgetsGallery/JSDemos/images/employees/06.png',
};

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly router = inject(Router);

  readonly currentUser = signal<User | null>(DEFAULT_USER);
  readonly isAuthenticated = computed(() => this.currentUser() !== null);
  readonly lastAuthenticatedPath = signal<string>(DEFAULT_PATH);

  // Backward compatibility getter for existing usages if needed
  get loggedIn(): boolean {
    return this.isAuthenticated();
  }

  setLastAuthenticatedPath(path: string): void {
    this.lastAuthenticatedPath.set(path);
  }

  async logIn(email: string, _password?: string): Promise<AuthResult<User>> {
    try {
      const user: User = { ...DEFAULT_USER, email };
      this.currentUser.set(user);
      await this.router.navigate([this.lastAuthenticatedPath()]);

      return {
        isOk: true,
        data: user,
      };
    } catch {
      return {
        isOk: false,
        message: 'Authentication failed',
      };
    }
  }

  async getUser(): Promise<AuthResult<User | null>> {
    return {
      isOk: true,
      data: this.currentUser(),
    };
  }

  async createAccount(_email: string, _password?: string): Promise<AuthResult> {
    try {
      await this.router.navigate(['/create-account']);
      return {
        isOk: true,
      };
    } catch {
      return {
        isOk: false,
        message: 'Failed to create account',
      };
    }
  }

  async changePassword(_password: string, _recoveryCode: string): Promise<AuthResult> {
    try {
      return {
        isOk: true,
      };
    } catch {
      return {
        isOk: false,
        message: 'Failed to change password',
      };
    }
  }

  async resetPassword(_email: string): Promise<AuthResult> {
    try {
      return {
        isOk: true,
      };
    } catch {
      return {
        isOk: false,
        message: 'Failed to reset password',
      };
    }
  }

  async logOut(): Promise<void> {
    this.currentUser.set(null);
    await this.router.navigate(['/login-form']);
  }
}

