import Vue from "vue";
import Vuex, { StoreOptions } from "vuex";
import { RootState } from "./types";
import { profile } from "./profile/index";
import createPersistedState from "vuex-persistedstate";

Vue.use(Vuex);

const store: StoreOptions<RootState> = {
  plugins: [createPersistedState({
    storage: window.sessionStorage,
  })],
  state: {
    version: "1.0.0",
  },
  modules: {
    profile,
  },
};

export default new Vuex.Store<RootState>(store);
