import { ActionTree } from "vuex";
import { ProfileState } from "./types";
import { RootState } from "../types";
import axios, { AxiosResponse } from "axios";
import { AuthenticationRequest } from "@/dto/AuthenticationRequest";

export const actions: ActionTree<ProfileState, RootState> = {
  authenticate(
    { commit },
    payload: AuthenticationRequest
  ): Promise<AxiosResponse> {
    return new Promise((resolve, reject) => {
      axios
        .post("http://localhost:40200/api/user/jwt/token", payload)
        .then((rsp) => {
          commit("authSuccess", rsp.data.jwt);
          resolve(rsp);
        })
        .catch((err) => {
          commit("authError");
          reject(err);
        });
    });
  },
  logout({ commit }): Promise<void> {
    return new Promise((resolve, reject) => {
      commit("logout");
      resolve();
    });
  },
};
