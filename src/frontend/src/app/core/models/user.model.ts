export interface User {
  email: string;
  avatarUrl?: string;
}

export interface UserMenuItem {
  text: string;
  icon?: string;
  onClick?: () => void;
}

export interface AuthResult<T = unknown> {
  isOk: boolean;
  data?: T;
  message?: string;
}

export interface LoginCredentials {
  email: string;
  password: string;
  rememberMe?: boolean;
}

export interface CreateAccountData {
  email: string;
  password: string;
  confirmedPassword?: string;
}

