<template>
  <!-- Main header container -->
  <div class="header d-flex justify-space-between">
    <div class="header-left d-flex align-center h-100-percent">
      <div class="icon-link icon-switch cursor-pointer"></div>
      <div class="icon-link icon-logo cursor-pointer"></div>
      <div class="header-left-title cursor-pointer">Tuyển dụng</div>
      <ms-input icon="icon-search" v-model="search" placeholder="Tìm kiếm tin tuyển dụng, ứng viên, nhân tài..."
        :object-style="styleObject" />
    </div>
    <div class="header-right d-flex align-center h-100-percent">
      <div class="recruitment-page d-flex align-center cursor-pointer">
        <div class="icon icon-global mr-10"></div>
        <div class="website-text">Website tuyển dụng</div>
      </div>
      <div class="icon-link mx-16 icon-notifi cursor-pointer mr-20px"></div>
      <div class="icon-link mx-16 icon-cart cursor-pointer mr-20px"></div>
      <div class="user-control-pannel d-flex align-center">
        <div class="icon-link mx-16 icon-invite cursor-pointer mr-20px"></div>
        <div class="icon-link mx-16 icon-message cursor-pointer mr-20px"></div>
        <div class="icon-link mx-16 icon-ring cursor-pointer mr-20px"></div>
        <div class="icon-link mx-16 icon-helpmenu cursor-pointer mr-20px"></div>
        <div class="icon-link mx-16 icon-moremenu cursor-pointer mr-20px"></div>
        <div class="icon-link mx-16 icon-knowledge cursor-pointer mr-20px"></div>
        <div class="icon-link mx-16 icon-avatar cursor-pointer mr-12px"></div>
      </div>
    </div>
  </div>
</template>

<script setup>
import MsInput from '@/components/ms-input/MsInput.vue';
import { watch, ref } from 'vue';

const search = ref("");
const styleObject = ref({
  height: "32px",
  width: "365px",
  border: "none",
  borderRadius: "5px",
  outline: "none",
  backgroundColor: "#f2f2f2",
});
watch(search, (newval) => {
  console.log(newval);
})
</script>
<style scoped>
.header {
  height: 48px;
  padding: 0 16px;
}
/* User control pannel icon-avatar */
.user-control-pannel .icon-avatar {
  margin-left: 4px;
}

/* Header left */
/* Header icon logo */
.icon-logo {
  margin-left: 16px;
}

/* Title name header */
.header-left-title {
  font-size: 18px;
  font-weight: 700;
  margin: 0 24px 0 12px;
}

/* Header right */
.recruitment-page {
  margin-right: 20px;
}

.recruitment-page:hover {
  color: #2a7efc;
}
.recruitment-page:hover .icon-global {
  background-color: #2a7efc;
}

.recruitment-page .icon-global {
  margin-right: 10px;
}
</style>