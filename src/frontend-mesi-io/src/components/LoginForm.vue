<template>
  <div>
    <form @submit.prevent="submitLogin">
      <div class="form-group">
        <label for="user-email-input">Email address</label>
        <input
          v-model="enteredUserEmail"
          type="email"
          class="form-control"
          id="user-email-input"
          placeholder="Email"
          required
        />
      </div>
      <div class="form-group">
        <label for="user-pw-input">Password</label>
        <input
          v-model="enteredPassword"
          type="password"
          class="form-control"
          id="user-pw-input"
          placeholder="Password"
          required
        />
      </div>
      <button type="submit" class="btn btn-primary">Submit</button>
    </form>
    <div class="login-error-message" v-if="hasError">
      * Invalid username or password.
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Action, namespace } from "vuex-class";
import { Component, Prop } from "vue-property-decorator";
import { AuthenticationRequest } from "@/dto/AuthenticationRequest";

@Component
export default class LoginForm extends Vue {
  private enteredUserEmail = "";
  private enteredPassword = "";
  private hasError = false;

  @(namespace("profile").Action("authenticate")) authenticate: any;

  submitLogin(): void {
    const authenticationRequest: AuthenticationRequest = {
      email: this.enteredUserEmail,
      password: this.enteredPassword,
    };
    this.authenticate(authenticationRequest)
      .then(() => this.$router.push("/"))
      .catch(() => this.hasError = true);
  }
}
</script>

<style lang="scss" scoped>
.login-error-message {
  padding-top: 10px;
  color: #ff0000;
}
</style>
