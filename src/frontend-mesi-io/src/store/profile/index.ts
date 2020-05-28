import { ProfileState, AuthenticationStatus } from './types';
import { Module } from 'vuex';
import { RootState } from '../types';
import { actions } from "./actions";
import { mutations } from "./mutations";
import { getters } from "./getters";

export const state: ProfileState = {
    token: localStorage.getItem("authentication_token") || "",
    user: {
        name: localStorage.getItem("username") || "",
        email: localStorage.getItem("useremail") || ""
    },
    status: AuthenticationStatus.Anonymous,
}

export const profile: Module<ProfileState, RootState> = {
    namespaced: true,
    state,
    getters,
    actions,
    mutations
}