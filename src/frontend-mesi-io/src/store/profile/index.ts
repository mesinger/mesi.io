import { ProfileState } from './types';
import { Module } from 'vuex';
import { RootState } from '../types';
import { actions } from "./actions";
import { mutations } from "./mutations";
import { getters } from "./getters";

export const state: ProfileState = {
    user: undefined,
    token: undefined,
    loggedIn: false,
    loginAttempts: 0,
}

export const profile: Module<ProfileState, RootState> = {
    namespaced: true,
    state,
    getters,
    actions,
    mutations
}