<template>
  <div class="login-form">
    <form @submit="submitLogin">
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
import { Component, Prop } from 'vue-property-decorator';
import { AuthenticationRequest } from "@/dto/AuthenticationRequest";

@Component
export default class LoginForm extends Vue {
  private enteredUserEmail = "";
  private enteredPassword = "";
  @Prop({required: true, default: false}) hasError!: boolean;

  @namespace("profile").Action("authenticate") authenticate: any;

  submitLogin(e: Event): void {
    const authenticationRequest: AuthenticationRequest = {email: this.enteredUserEmail, password: this.enteredPassword};
    this.authenticate(authenticationRequest);

    e.preventDefault();
  }
}
</script>

<style lang="scss" scoped>
.login-form {
  padding: 10px;
  padding-bottom: 20px;
}
</style>
