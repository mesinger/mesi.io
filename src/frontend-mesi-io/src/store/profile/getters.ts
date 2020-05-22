import { GetterTree } from "vuex";
import { ProfileState, User } from "./types";
import { RootState } from "../types";

export const getters: GetterTree<ProfileState, RootState> = {
  isLoggedIn(state): boolean {
    if (!state.loggedIn) {
      return false;
    }

    if (
      state.user === undefined ||
      state.user.userName === undefined ||
      state.user.email === undefined
    ) {
      return false;
    }

    if (
      state.token === undefined ||
      state.token.exp < new Date().getUTCMilliseconds()
    ) {
      return false;
    }

    return true;
  },
  numberOfLoginAttempts(state): number {
    return state.loginAttempts;
  },
  currentUser(state): User | undefined {
    return state.user;
  },
};
