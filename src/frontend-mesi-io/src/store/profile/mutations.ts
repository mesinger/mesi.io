/* eslint-disable no-use-before-define */
import { MutationTree } from "vuex";
import { ProfileState, User } from "./types";
import { JwtTokenResponse } from "@/dto/JwtTokenResponse";
import { decode } from "@/util/jwt";

export const mutations: MutationTree<ProfileState> = {
  authenticateError(state) {
    state.user = undefined;
    state.token = undefined;
    state.loggedIn = false;
    state.loginAttempts++;
  },
  authenticateSuccess(state, payload: JwtTokenResponse) {
    const decodedToken = decode(payload.jwt);
    state.user = { userName: decodedToken.name, email: decodedToken.email };
    state.token = {
      raw: payload.jwt,
      iss: decodedToken.iss,
      name: decodedToken.name,
      email: decodedToken.email,
      exp: decodedToken.exp,
    };
    state.loggedIn = true;
    state.loginAttempts++;
  },
  logout(state) {
    state.user = undefined;
    state.token = undefined;
    state.loggedIn = false;
    state.loginAttempts = 0;
  }
};
