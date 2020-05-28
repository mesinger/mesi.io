<template>
  <div id="app">
    <NavBar></NavBar>

    <main class="bg-surface">
      <div id="main">
        <div class="pt-3"></div>

        <router-view />
      </div>
    </main>

    <Footer></Footer>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator";
import NavBar from "@/components/Navbar.vue";
import Footer from "@/components/Footer.vue";
@Component({
  components: {
    NavBar,
    Footer,
  },
})
export default class App extends Vue {}
</script>

<style lang="scss">
$primary-color: #b71c1c;
$primary-dark-color: #7f0000;
$on-primary-color: #ffffff;
$on-primary-dark-color: #ffffff;
$secondary-color: #455a64;
$on-secondary-color: #ffffff;
$surface-color: #ffffff;
$on-surface-color: #000000;
$error-color: #ff0000;
$on-error-color: #ffffff;
.bg-primary {
  background-color: $primary-color !important;
}
.text-on-primary {
  color: $on-primary-color;
}
.bg-secondary {
  background-color: $secondary-color !important;
}
.text-on-secondary {
  color: $on-secondary-color;
}
* {
  padding: 0px;
  margin: 0px;
}
html,
body {
  height: 100%;
}
main {
  min-height: 100%;
}
.main {
  overflow: auto;
  padding-bottom: 150px;
}
.footer {
  position: relative;
  margin-top: -150px;
  height: 150px;
  clear: both;
  padding-top: 20px;
}
.w-24 {
  width: 24%;
}
.w-49 {
  width: 49%;
}
.hidden {
  height: 0px;
}
.align-bottom-container {
  position: absolute;
  bottom: 0;
  padding-bottom: 2px;
}
a {
  color: black;
  &:hover {
    color: #111111;
  }
}
.button-primary {
  background-color: $primary-color !important;
  color: $on-primary-color !important;
  &:hover {
    background-color: $primary-dark-color !important;
    color: $on-primary-dark-color !important;
  }
}
.button-navbar {
  background-color: $primary-color !important;
  color: $on-primary-color !important;
  &:hover {
    background-color: $primary-dark-color !important;
    color: $on-primary-dark-color !important;
  }
}
.dashboard-item-container {
  padding: 6px 5px 6px 5px;
}
.dashboard-item {
  padding: 4px 6px 4px 6px;
  box-shadow: 5px 6px 10px rgb(214, 211, 211);
}
</style>
