import { GetterTree } from "vuex";
import { ProfileState, AuthenticationStatus } from "./types";
import { RootState } from "../types";
import { decode } from '@/util/jwt';

export const getters: GetterTree<ProfileState, RootState> = {
  isLoggedIn(state): boolean {
    return !!state.token && decode(state.token).exp > (Date.now() / 1000);
  },
  authStatus(state): AuthenticationStatus {
    return state.status;
  },
  userName(state): string {
    return (state.user !== undefined) ? state.user.name : "";
  },
  userId(state): string {
    return state.token ? decode(state.token).sub : "";
  },
  authToken(state): string {
    return state.token;
  }
};
