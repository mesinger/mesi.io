<template>
  <div class="login-form">
    <form @submit="submitLogin">
      <div class="form-group">
        <label for="user-email-input">Email address</label>
        <input
          v-model="userEmail"
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
          v-model="userPassword"
          type="password"
          class="form-control"
          id="user-pw-input"
          placeholder="Password"
          required
        />
      </div>
      <button type="submit" class="btn btn-primary">Submit</button>
    </form>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import axios from "axios";

export default class Login extends Vue {
  private userEmail = "";
  private userPassword = "";

  submitLogin(): void {
    return;
  }

  authenticate(): void {
    return;
  }
}
</script>

<style lang="scss" scoped>
.login-form {
  padding: 10px;
  padding-bottom: 20px;
}
</style>
