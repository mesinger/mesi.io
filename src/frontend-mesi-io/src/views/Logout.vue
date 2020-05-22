<template>
    <div>
        Logout
    </div>
</template>

<script lang="ts">
import Vue from 'vue';
import { Component } from "vue-property-decorator";
import { Action, namespace } from "vuex-class";

@Component
export default class Logout extends Vue{
    @namespace("profile").Action("logout") logout: any;

    mounted() {
        this.logout();
        this.$router.push("/");
    }
}
</script>
