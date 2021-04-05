using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TaskNote.Platform
{
    /// <summary>
    /// <see cref="INotifyPropertyChanged"/>を実装するViewModelの基底クラス
    /// </summary>
    public abstract class BindableBase : INotifyPropertyChanged
    {
        /// <summary>
        /// プロパティ値が変更されたときに発生します
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// プロパティがすでに目的の値と一致しているかどうかを確認します
        /// プロパティを設定し、必要な場合にのみリスナーに通知します
        /// </summary>
        /// <typeparam name="T">プロパティのタイプ</typeparam>
        /// <param name="storage">ゲッターとセッターの両方を持つプロパティへの参照</param>
        /// <param name="value">プロパティに必要な値</param>
        /// <param name="propertyName">リスナーに通知するために使用されるプロパティの名前。 
        /// この値はオプションであり、コンパイラから呼び出されたときに自動的に提供できます。<see cref="CallerMemberNameAttribute"/>をサポートします。</param>
        /// <returns>値が変更された場合はTrue、既存の値が必要な値</returns>
        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value)) return false;

            storage = value;
            RaisePropertyChanged(propertyName);

            return true;
        }

        /// <summary>
        /// プロパティがすでに目的の値と一致しているかどうかを確認します。
        /// プロパティを設定し、必要な場合にのみリスナーに通知します。
        /// </summary>
        /// <typeparam name="T">プロパティのタイプ</typeparam>
        /// <param name="storage">ゲッターとセッターの両方を持つプロパティへの参照</param>
        /// <param name="value">プロパティに必要な値</param>
        /// <param name="propertyName">リスナーに通知するために使用されるプロパティの名前。 
        /// この値はオプションであり、コンパイラから呼び出されたときに自動的に提供できます。<see cref="CallerMemberNameAttribute"/>をサポートします。</param>
        /// <param name="onChanged">プロパティ値が変更された後に呼び出されるアクション</param>
        /// /// <returns>値が変更された場合はTrue、既存の値が必要な値</returns>
        protected virtual bool SetProperty<T>(ref T storage, T value, Action onChanged, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value)) return false;

            storage = value;
            onChanged?.Invoke();
            RaisePropertyChanged(propertyName);

            return true;
        }

        /// <summary>
        /// このオブジェクトのPropertyChangedイベントを発生させます
        /// </summary>
        /// <param name="propertyName">リスナーに通知するために使用されるプロパティの名前。 
        /// この値はオプションであり、コンパイラから呼び出されたときに自動的に提供できます
        /// <see cref="CallerMemberNameAttribute"/>をサポートします</param>
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// このオブジェクトのPropertyChangedイベントを発生させます
        /// </summary>
        /// <param name="args">The PropertyChangedEventArgs</param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChanged?.Invoke(this, args);
        }
    }
}
