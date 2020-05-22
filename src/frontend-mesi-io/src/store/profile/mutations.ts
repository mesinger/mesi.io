/* eslint-disable no-use-before-define */
import { MutationTree } from "vuex";
import { ProfileState, User } from "./types";
import { JwtTokenResponse } from "@/dto/JwtTokenResponse";
import { decode } from "@/util/jwt"

export const mutations: MutationTree<ProfileState> = {
  authenticateError(state) {
    state.user = undefined;
    state.token = undefined;
    state.loggedIn = false;
    state.loginAttempts++;
  },
  authenticateSuccess(state, payload: JwtTokenResponse) {
    const decodeToken = decode(payload.jwt);
    const user: User = { userName: decodeToken.name, email: decodeToken.email };
    state.user = user;
    state.token = payload;
    state.loggedIn = true;
    state.loginAttempts = 0;
  }
};
