<template>
  <div class="login-form">
    <LoginForm :hasError="hasError"></LoginForm>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import axios from "axios";
import { State, Action, Getter, namespace } from "vuex-class";
import { ProfileState, User } from "../store/profile/types";
import { Component, Watch } from "vue-property-decorator";
import { AuthenticationRequest } from "@/dto/AuthenticationRequest";
import LoginForm from "@/components/LoginForm.vue";

@Component({
  components: {
    LoginForm,
  },
})
export default class Login extends Vue {
  @(namespace("profile").Getter("isLoggedIn")) isLoggedIn!: boolean;
  @(namespace("profile").Getter("numberOfLoginAttempts"))
  loginAttempts!: number;

  private hasError = false;

  @Watch("loginAttempts")
  onLoginAttemptsChanged(attempts: number) {
    if (this.isLoggedIn) {
      this.hasError = false;
      this.$router.push("/");
    }
    else {
      this.hasError = true;
    }
  }

  mounted() {
    if(this.isLoggedIn) {
      this.$router.push("/");
    }
  }
}
</script>

<style lang="scss" scoped>
.login-form {
  padding: 10px;
  padding-bottom: 20px;
}
</style>
