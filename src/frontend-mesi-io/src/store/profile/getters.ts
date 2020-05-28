import { GetterTree } from "vuex";
import { ProfileState, AuthenticationStatus } from "./types";
import { RootState } from "../types";

export const getters: GetterTree<ProfileState, RootState> = {
  isLoggedIn(state): boolean {
    return !!state.token;
  },
  authStatus(state): AuthenticationStatus {
    return state.status;
  },
  userName(state): string {
    return (state.user !== undefined) ? state.user.name : "";
  }
};
