/* eslint-disable no-use-before-define */
import { MutationTree } from "vuex";
import { ProfileState, AuthenticationStatus } from "./types";
import { decode } from "@/util/jwt";

export const mutations: MutationTree<ProfileState> = {
  authSuccess(state: ProfileState, token: string) {
    state.status = AuthenticationStatus.Authenticated;
    state.token = token;
    localStorage.setItem("authentication_token", token);

    const decoded = decode(token);
    const user = {name: decoded.name, email: decoded.email};
    state.user = {name: decoded.name, email: decoded.email};
    localStorage.setItem("username", user.name);
    localStorage.setItem("useremail", user.email);
  },
  authError(state) {
    state.status = AuthenticationStatus.Error;
    localStorage.removeItem("authentication_token");
    localStorage.removeItem("username");
    localStorage.removeItem("useremail");
    state.token = "";
  },
  logout(state) {
    state.status = AuthenticationStatus.Anonymous;
    localStorage.removeItem("authentication_token");
    localStorage.removeItem("username");
    localStorage.removeItem("useremail");
    state.token = "";
  }
};
