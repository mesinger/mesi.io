<template>
  <div>
    <div class="container-fluid pt-2 pb-2">
      <div class="rounded dashboard-item">
        <h1 class="display-4">Clipboard</h1>
        <input
          v-model="newEntry"
          type="text"
          class="form-control"
          placeholder="Add a new clipboard entry ..."
        />
        <button @click="addNewEntry" class="btn mt-2 w-100 button-primary">Add</button>
      </div>
    </div>

    <div class="container-fluid pt-2 pb-2">
      <div class="rounded dashboard-item">
        <h3>Previous entries</h3>

        <table class="table table-striped">
          <thead>
            <tr>
              <th scope="col">#</th>
              <th scope="col">Content</th>
              <th scope="col"></th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(entry, index) in entries" :key="index">
              <th scope="row">{{index + 1}}</th>
              <td>
                <strong>{{ entry.content.length > 20 ? entry.content.substring(0, 20) + '...' : entry.content }}</strong>
              </td>
              <td>
                <a @click="doCopy(entry.content)" class="copy-link">Copy</a>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator";
import axios from "axios";
import VueClipboard from "vue-clipboard2";
import { ClipboardEntry } from "@/entities/clipboard/ClipboardEntry";

Vue.use(VueClipboard);

@Component
export default class Clipboard extends Vue {
  entries = [];
  newEntry = "";

  mounted() {
    fetch("http://api.mesi.io/clipboard", {
      method: "get"
    })
      .then(response => {
        return response.json();
      })
      .then(data => {
        this.entries = data;
      });
  }

  doCopy(content: string) {
    this.$copyText(content);
  }

  addNewEntry() {
    axios
      .post("https://api.mesi.io/clipboard?content=" + this.newEntry)
      .then(response => {
        if (response.status === 201) {
          this.entries.unshift({ content: this.newEntry, timeStamp: "" });
          this.newEntry = "";
        }
      })
      .catch(error => console.log("can't access api"));
  }
}
</script>

<script>
import Vue from "vue";
import VueClipboard from "vue-clipboard2";
import axios from "axios";
import Component from "vue-class-component";
Vue.use(VueClipboard);
export default {
  name: "Clipboard",
  data() {
    return {
      entries: [],
      newEntry: ""
    };
  },
  mounted: function() {
    fetch("https://api.mesi.io/clipboard", {
      method: "get"
    })
      .then(response => {
        return response.json();
      })
      .then(data => {
        this.entries = data;
      });
  },
  methods: {
    doCopy: function(content) {
      this.$copyText(content);
    },
    addNewEntry: function() {
      axios
        .post("https://api.mesi.io/clipboard?content=" + this.newEntry)
        .then(response => {
          if (response.status === 201) {
            this.entries.unshift({ content: this.newEntry, timeStamp: "" });
            this.newEntry = "";
          }
        })
        .catch(error => console.log("can't access api"));
    }
  }
};
</script>

<style lang="scss" scoped>
.copy-link {
  &:hover {
    cursor: pointer;
    text-decoration: underline;
  }
}
</style>