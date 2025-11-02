<template>
  <div class="header d-flex w-100 justify-space-between align-center">
    <!-- Headder left -->
    <div class="header-left d-flex align-center">
      <div class="icon-link icon-switch"></div>
      <div>
        <div class="icon-link icon-logo"></div>
      </div>
      <div class="header-left-title">Tuyển dụng</div>
      <MsInput icon="icon-search" v-model="search" placeholder="Tìm kiếm tin tuyển dụng, ứng viên, nhân tài..."
        :object-style="styleObject" />
      <!-- <div>
        <div class="table-header-input">
          <div class="header-input-right icon icon-search"></div>
          <input class="header-left-input" type="text" placeholder="Tìm kiếm tin tuyển dụng, ứng viên, nhân tài..." />
        </div>
      </div> -->
    </div>
    <!-- Headder right -->
    <div class="header-right d-flex align-center">
      <div class="header-right-website mx-16 d-flex align-center">
        <div class="icon icon-global mr-10"></div>
        <div class="website-text">Website tuyển dụng</div>
      </div>
      <div class="icon-link mx-16 icon-notifi"></div>
      <div class="icon-link mx-16 icon-cart"></div>
      <div class="icon-link mx-16 icon-message"></div>
      <div class="icon-link mx-16 icon-ring"></div>
      <div class="icon-link mx-16 icon-helpmenu"></div>
      <div class="icon-link mx-16 icon-moremenu"></div>
      <div class="icon-link mx-16 icon-knowledge"></div>
      <div class="icon-link mx-16 icon-avatar"></div>
    </div>
  </div>
</template>

<script setup>
import MsInput from "@/components/ms-input/MsInput.vue";
import { ref } from "vue";

const search = ref("");
const styleObject = ref({
  border: "none",
  width: "500px",
});
</script>

<style scoped>
/* Header */
.header {
  background-color: #ffffff;
  padding: 8px 14px;
}

/* Header left */
.header-left {
  height: 30px;
  gap: 16px;
}

/* Header left title */
.header-left-title {
  font-weight: bold;
  font-size: 18px;
}

/* Header right */
.header-right {
  height: 32px;
}

/* Header right website tuyển dụng */
.header-right-website {
  cursor: pointer;
}

.header-left-input {
  height: 32px;
  width: 365px;
  border: none;
  border-radius: 5px;
  outline: none;
  background-color: #f2f2f2;
}

/* Hover website tuyển dụng */
.header-right-website:hover .icon-global {
  background-color: blue;
}

.header-right-website:hover .website-text {
  color: blue;
}

.website-text {
  font-size: 14px;
}
</style>
