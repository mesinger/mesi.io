import { ActionTree } from "vuex";
import { ProfileState } from "./types";
import { RootState } from "../types";
import axios from "axios";
import { AuthenticationRequest } from '@/dto/AuthenticationRequest';
import { JwtTokenResponse } from '@/dto/JwtTokenResponse';

export const actions: ActionTree<ProfileState, RootState> = {
  authenticate({ commit }, payload: AuthenticationRequest): any {
    axios.post("http://localhost:5000/api/user/jwt/token", payload)
    .then(response => {
      if(response.status === 200) {
        commit("authenticateSuccess", response.data);
      }
    })
    .catch(reason => {
      commit("authenticateError");
    });
  },
  logout({ commit }): any {
    commit("logout");
  }
};
