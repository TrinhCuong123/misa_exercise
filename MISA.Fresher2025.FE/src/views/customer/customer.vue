<template>
  <div class="customer-page w-100-percent h-100-percent d-flex flex-column">
    <div class="customer-header d-flex justify-space-between align-center">
      <div class="header-title">
        Khách hàng
      </div>
      <div class="header-button d-flex align-center">
        <div class="button-create d-flex align-center">
          <div class="icon icon-plus"></div>
          <div class="button-title">Thêm khách hàng</div>
        </div>
        <div class="button-dropdown d-flex align-center">
          <div class="icon icon-down"></div>
        </div>
      </div>
    </div>
    <div class="customer-content flex1">
      <div class="content-table w-100-percent h-100-percent"></div>
    </div>
  </div>
</template>

<style scoped>
/* .customer-page {

} */

.customer-header {
  height: 50px;
  padding: 16px 24px 0;
}

.header-title {
  font-size: 20px;
  color: #1E2633;
  font-weight: 700;
}

.button-create {
  background-color: #2680eb;
  color: #fff;
  font-weight: 500;
  height: 36px;
  padding: 8px 12px;
  border-radius: 4px 0 0 4px;
}
.button-create .button-title{
  margin-left: 8px;
}

.button-dropdown {
  background-color: #2680eb;
  color: #fff;
  font-weight: 500;
  height: 36px;
  padding: 8px 12px;
  border-radius: 0 4px 4px 0;
  border-left: 1px solid #176cd1;
}

.customer-content {
  padding: 24px;
}

.content-table {
  background-color: #fff;
}
</style>