<template>
  <div class="login-form">
    <form @submit="submitRegistration">
      <div class="form-group">
        <label for="user-username-input">Username</label>
        <input
          v-model="userName"
          type="text"
          class="form-control"
          id="user-username-input"
          placeholder="Username"
          required
        />
      </div>
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
      <button type="submit" class="btn btn-primary">Register</button>
    </form>
    <div class="form-error-message" v-if="hasError">
      * {{ errorMessage }}
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator";
import axios from "axios";

@Component
export default class Registration extends Vue {
  private userName = "";
  private userEmail = "";
  private userPassword = "";

  private errorMessage = "";
  private readonly defaultErrorMessage = "We are currently unable to register new users. We apologise for that."

  submitRegistration(e: Event): void {
    axios
      .post("http://localhost:40200/api/user/register", {
        email: this.userEmail,
        password: this.userPassword,
        username: this.userName,
      })
      .then((response) => {
        if(response.status === 201) {
          this.$router.push("/login");
        }
        else {
          this.errorMessage = this.defaultErrorMessage;
        }
      })
      .catch((error) => {
        if(error.response.status === 400) {
          this.errorMessage = error.response.data.message;
        }
        else {
          this.errorMessage = this.defaultErrorMessage;
        }
      });

    e.preventDefault();
  }

  get hasError(): boolean {
    return this.errorMessage !== "";
  }
}
</script>

<style lang="scss" scoped>
.login-form {
  padding: 10px;
  padding-bottom: 20px;
}

.form-error-message {
  padding-top: 10px;
  color: #ff0000;
}
</style>
