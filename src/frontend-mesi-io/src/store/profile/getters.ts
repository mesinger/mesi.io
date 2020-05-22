import { GetterTree } from 'vuex';
import { ProfileState, User } from './types';
import { RootState } from '../types';

export const getters: GetterTree<ProfileState, RootState> = {
    isLoggedIn(state): boolean {
        return state.loggedIn && state.user !== undefined;
    },
    numberOfLoginAttempts(state): number {
        return state.loginAttempts;
    },
    currentUser(state): User | undefined {
        return state.user;
    }
}