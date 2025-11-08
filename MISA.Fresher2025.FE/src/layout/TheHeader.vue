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
      <div class="header-right-website d-flex align-center cursor-pointer">
        <div class="icon icon-global mr-10"></div>
        <div class="website-text">Website tuyển dụng</div>
      </div>
      <div class="icon-link mx-16 icon-notifi cursor-pointer"></div>
      <div class="icon-link mx-16 icon-cart cursor-pointer"></div>
      <div class="icon-link mx-16 icon-message cursor-pointer"></div>
      <div class="icon-link mx-16 icon-ring cursor-pointer"></div>
      <div class="icon-link mx-16 icon-helpmenu cursor-pointer"></div>
      <div class="icon-link mx-16 icon-moremenu cursor-pointer"></div>
      <div class="icon-link mx-16 icon-knowledge cursor-pointer"></div>
      <div class="icon-link mx-16 icon-avatar cursor-pointer"></div>
    </div>
  </div>
</template>

<script setup>

</script>
<style scoped>
.header {
  height: 50px;
  padding: 0 16px;
}
</style>